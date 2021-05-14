using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Repositorio.Repositorios
{
    public interface EncryptDecrypt
    {
        string Encrypt(string Data);
        string Decrypt(string Data);
    }


    public class UsuarioRepository : BaseRepository<Usuario>
    {

        public Usuario add(string username, string senha)
        {
            Usuario user = new Usuario();
            try
            {
                user = new Usuario() { Ativo = "S", IdGrupoAcesso = 1, Senha = senha, Username = username };
                using (_context = new FreelancerSpaceContext())
                {
                    _context.Usuarios.Add(user);
                    _context.SaveChanges();
                }
                return user;
            }
            catch (Exception ex)
            {
                return user;
                throw;
            }
        }


        public new List<Usuario> getAll()
        {
            using (_context = new FreelancerSpaceContext())
            {
                List<Usuario> list = _context.Usuarios.Include("IdGrupoAcessoNavigation").ToList();
                return list;
            }
        }

        public Usuario validarLogin(string username, string senha)
        {
            Usuario user = new Usuario();
            using (_context = new FreelancerSpaceContext())
            {
                user = _context.Usuarios.Include("IdGrupoAcessoNavigation").FirstOrDefault(x => x.Username == username && 
                                                                                                x.Senha == Encrypt(senha) && 
                                                                                                x.Ativo.Equals("S"));
            }
            return user;
        }

        public string Encrypt(string Data)
        {
            try
            {
                string passPhrase = "freelancer";
                string saltValue = "space";
                string hashAlgorithm = "MD5";
                int passwordIterations = 1;
                string initVector = "koxskfruvdslbsxu";
                int keySize = 128;

                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(Data);

                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string cipherText = Convert.ToBase64String(cipherTextBytes);

                return cipherText;
            }
            catch { }

            return "";
        }

        private string Decrypt(string Data)
        {
            try
            {
                string passPhrase = "freelancer";
                string saltValue = "space";
                string hashAlgorithm = "MD5";
                int passwordIterations = 1;
                string initVector = "koxskfruvdslbsxu";
                int keySize = 128;

                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(Data);

                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                return plainText;
            }
            catch { }

            return "";
        }
    }
}
