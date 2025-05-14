namespace ClientService.CustomValidations
{
    public interface IValidateCpfCnpj
    {
        bool CpfCnpjIsValid(string cpfCnpj);
    }
    public class ValidateCpfCnpj : IValidateCpfCnpj
    {
        private const int CpfLength = 11;
        private const int CnpjLength = 14;

        private static readonly int[] MultipliersCpf = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
        private static readonly int[] MultipliersCnpj = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        
        public bool CpfCnpjIsValid(string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(cpfCnpj))
            {
                return false;
            }
            return (CpfIsValid(cpfCnpj) || CnpjIsValid(cpfCnpj));
        }
        private static int CalculateDigits(string cnpjCpfNoMask, int length, int shift, int[] multipliers)
        {
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += ((int)cnpjCpfNoMask[i] - '0') * multipliers[i + shift];
            }

            int rest = sum % 11;
            return rest < 2 ? 0 : 11 - rest;
        }

        private static string RemoveMask(string cnpjCpf)
        {
            return new string(cnpjCpf.Where(char.IsDigit).ToArray());
        }

        private static bool AllDigitsIdentical(string cnpjCpf)
        {
            return cnpjCpf.All(digit => digit == cnpjCpf[0]);
        }

        private static bool CpfIsValid(string cpf)
        {
            string cpfNoMask = RemoveMask(cpf);

            if (cpfNoMask.Length != CpfLength || AllDigitsIdentical(cpfNoMask))
            {
                return false;
            }

            int digit1 = CalculateDigits(cpfNoMask, cpfNoMask.Length - 2, 1, MultipliersCpf);
            int digit2 = CalculateDigits(cpfNoMask, cpfNoMask.Length - 1, 0, MultipliersCpf);

            return cpfNoMask.EndsWith(String.Concat(digit1, digit2));
        }

        private static bool CnpjIsValid(string cnpj)
        {
            string cnpjNoMask = RemoveMask(cnpj);

            if (cnpjNoMask.Length != CnpjLength || AllDigitsIdentical(cnpjNoMask))
            {
                return false;
            }

            int digit1 = CalculateDigits(cnpjNoMask, cnpjNoMask.Length - 2, 1, MultipliersCnpj);
            int digit2 = CalculateDigits(cnpjNoMask, cnpjNoMask.Length - 1, 0, MultipliersCnpj);

            return cnpjNoMask.EndsWith(String.Concat(digit1, digit2));
        }

    }
}


