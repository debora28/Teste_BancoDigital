//using Newtonsoft.Json.Linq;
//using System.ComponentModel.DataAnnotations;

//namespace UserService.CustomValidations
//{
//    public class CpfValidationAttribute : ValidationAttribute
//    {
//        public bool ValidarCpf(string cpf)
//        {
//            bool validacao1 = false;
//            bool validacao2 = false;
//            bool validacao3 = false;
//            try
//            {
//                if (cpf.Length == 11 && cpf.All(char.IsNumber) == true)
//                {
//                    // Primeira parte da validação: Dígito verificador nro. 1:
//                    int total1 = 0;
//                    int digito1 = 0;
//                    int j = 10;

//                    for (int i = 0; i <= 8; i++)
//                    {
//                        total1 += (Int32.Parse(cpf[i].ToString()) * j);
//                        j--;
//                    }
//                    int resto1 = (total1 * 10) % 11;
//                    if (resto1 <= 9)
//                    {
//                        digito1 = resto1;
//                    }
//                    if (digito1 == Int32.Parse(cpf[9].ToString()))
//                    {
//                        validacao1 = true;
//                    }

//                    // Segunda parte da validação: Dígito verificador nro. 2:
//                    int total2 = 0;
//                    int digito2 = 0;
//                    j = 11;

//                    for (int i = 0; i <= 9; i++)
//                    {
//                        total2 += (Int32.Parse(cpf[i].ToString()) * j);
//                        j--;
//                    }
//                    int resto2 = (total2 * 10) % 11;
//                    if (resto2 <= 9)
//                    {
//                        digito2 = resto2;
//                    }
//                    if (digito2 == Int32.Parse(cpf[10].ToString()))
//                    {
//                        validacao2 = true;
//                    }

//                    //Terceira Validação: CPFs formados por números iguais, como 111.111.111-11, são inválidos.
//                    if (cpf.All(digito => digito == cpf[0]))
//                    {
//                        validacao3 = false;
//                    }
//                    else
//                    {
//                        validacao3 = true;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//            }

//            if (validacao1 == true && validacao2 == true && validacao3 == true)
//            {
//                Console.WriteLine("CPF válido.");
//                return true;
//            }
//            else
//            {
//                Console.WriteLine("CPF inválido.");
//                return false;
//            }
//        }
//    }
//}
