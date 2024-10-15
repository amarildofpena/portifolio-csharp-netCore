using System.Text.Json;

namespace CoreBusiness.Source.Helper
{
	public static class CommonFunctionsStatic
	{
		public static string ConvertObjectToJson(object? obj)
		{
			return JsonSerializer.Serialize(obj);
		}

		#region Validacoes
		public static bool ValidateCPF(string cpf)
		{
			cpf = cpf.Replace(".", "").Replace("-", "");

			if (cpf.Length != 11)
				return false;

			bool allDigitsAreEqual = true;
			for (int i = 1; i < 11; i++)
			{
				if (cpf[i] != cpf[0])
				{
					allDigitsAreEqual = false;
					break;
				}
			}

			if (allDigitsAreEqual || cpf == "12345678909")
				return false;

			int[] multipliersForFirstDigit = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multipliersForSecondDigit = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

			string tempCpf = cpf.Substring(0, 9);
			int sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(tempCpf[i].ToString()) * multipliersForFirstDigit[i];

			int remainder = sum % 11;
			remainder = remainder < 2 ? 0 : 11 - remainder;

			string digit = remainder.ToString();
			tempCpf += digit;
			sum = 0;

			for (int i = 0; i < 10; i++)
				sum += int.Parse(tempCpf[i].ToString()) * multipliersForSecondDigit[i];

			remainder = sum % 11;
			remainder = remainder < 2 ? 0 : 11 - remainder;

			digit += remainder.ToString();

			return cpf.EndsWith(digit);
		}

		public static bool ValidateCNPJ(string cnpj)
		{
			cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

			if (cnpj.Length != 14)
				return false;

			bool allDigitsAreEqual = true;
			for (int i = 1; i < 14; i++)
			{
				if (cnpj[i] != cnpj[0])
				{
					allDigitsAreEqual = false;
					break;
				}
			}

			if (allDigitsAreEqual)
				return false;

			int[] multipliersForFirstDigit = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multipliersForSecondDigit = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

			string tempCnpj = cnpj.Substring(0, 12);
			int sum = 0;

			for (int i = 0; i < 12; i++)
				sum += int.Parse(tempCnpj[i].ToString()) * multipliersForFirstDigit[i];

			int remainder = sum % 11;
			remainder = remainder < 2 ? 0 : 11 - remainder;

			string digit = remainder.ToString();
			tempCnpj += digit;
			sum = 0;

			for (int i = 0; i < 13; i++)
				sum += int.Parse(tempCnpj[i].ToString()) * multipliersForSecondDigit[i];

			remainder = sum % 11;
			remainder = remainder < 2 ? 0 : 11 - remainder;

			digit += remainder.ToString();

			return cnpj.EndsWith(digit);
		}
		#endregion



	}
}
