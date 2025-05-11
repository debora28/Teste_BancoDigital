namespace UserService.CustomValidations
{
    public interface IValidateCpfCnpj
    {
        bool CpfCnpjIsValid(string cpfCnpj);
    }
    public class ValidateCpfCnpj : IValidateCpfCnpj
    {
        public bool CpfCnpjIsValid(string cpfCnpj)
        {
            return (CpfIsValid(cpfCnpj) || CnpjIsValid(cpfCnpj));
        }
        private static int CalcularDigitos(string cnpjCpfSemMascara, int length, int shift, int[] multiplicadores)
        {
            int soma = 0;

            for (int i = 0; i < length; i++)
            {
                soma += ((int)cnpjCpfSemMascara[i] - '0') * multiplicadores[i + shift];
            }

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        private static bool CpfIsValid(string cpf)
        {
            string cpfSemMascara = new string(cpf.Where(char.IsDigit).ToArray());
            int[] multiplicadoresCpf = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cpfSemMascara.Length != 11 || cpfSemMascara.All(digito => digito == cpfSemMascara[0]))
            {
                return false;
            }

            int digito1 = CalcularDigitos(cpfSemMascara, cpfSemMascara.Length - 2, 1, multiplicadoresCpf);
            int digito2 = CalcularDigitos(cpfSemMascara, cpfSemMascara.Length - 1, 0, multiplicadoresCpf);

            return cpfSemMascara.EndsWith(String.Concat(digito1, digito2));
        }

        private static bool CnpjIsValid(string cnpj)
        {
            string cnpjSemMascara = new string(cnpj.Where(char.IsDigit).ToArray());
            int[] multiplicadoresCnpj = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cnpjSemMascara.Length != 14 || cnpjSemMascara.All(digito => digito == cnpjSemMascara[0]))
            {
                return false;
            }

            int digito1 = CalcularDigitos(cnpjSemMascara, cnpjSemMascara.Length - 2, 1, multiplicadoresCnpj);
            int digito2 = CalcularDigitos(cnpjSemMascara, cnpjSemMascara.Length - 1, 0, multiplicadoresCnpj);

            return cnpjSemMascara.EndsWith(String.Concat(digito1, digito2));
        }
        
    }
}


