using PersistenceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class LoginService
    {
        private readonly UsersRepository _repository;

        public LoginService() 
        {
            _repository = new UsersRepository();
        }

        public bool ValidateUser(string username, string password)
        {
            if (!_repository.UserExists(username))
            {
                Console.WriteLine("Usuario no encontrado o no está activo.");
                return false;
            }

            var (storedHash, salt) = _repository.GetPasswordAndSalt(username);

            if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(salt))
            {
                Console.WriteLine("Error al obtener la contraseña o el salt.");
                return false;
            }

            string passwordHash = HashPassword(password, salt);

            if (passwordHash == storedHash)
            {
                Console.WriteLine("Login exitoso.");
                return true;
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
                return false;
            }
        }


        private string HashPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(salt))
                throw new ArgumentException("Password o Salt no pueden ser nulos o vacíos.");

            string cleanPassword = password.Trim();
            string cleanSalt = salt.Trim();

            string saltedPassword = cleanPassword + cleanSalt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hash = sha256.ComputeHash(bytes);

                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
