using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text.RegularExpressions;
using Task1;

namespace Lesson6Practice
{
    public class Program
    {
        private static void Main()
        {
            /* Необходимо создать программу по регистрации и авторизации пользователя. 
             * Пользователь может авторизироваться, регистрироваться, и выходить из учетки, если авторизирован.
             * Решить с использованием Dictionary.
             * +к уже написаной программе добавить валидацию имени пользователя
             * (нельзя использовать кириллицу и спец.символы), также нужно расширить функционал для админа, 
             * чтобы у него была возможность редактировать(имя, пароль) и удалять пользователей.
             */
            var userService = new UserService();

            while (true)
                userService.ChooseAction();
        } 
    }
}