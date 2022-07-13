using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Utils
{
    class RegexPatterns
    {
        //Phải là kí tự hợp lệ dùng cho tên thật
        public static string Name { get; } = @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$";
        //Phải đúng định dạng Email
        public static string Email { get; } = @"^[a-z][a-z0-9_\.]{2,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$";
        //Đúng ngày sinh dd/mm/yyyy
        public static string DateofBirth { get; } = @"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$";
        //Tối thiểu 8 kí tự, ít nhất 1 chữ cái và 1 chữ số
        public static string Password { get; } = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
    }
}
