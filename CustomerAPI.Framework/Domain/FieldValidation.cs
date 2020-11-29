using System;
using System.Collections.Generic;

namespace CustomerAPI.Framework.Domain
{
    public class FieldValidation<T> where T : BaseResult
    {

        private readonly T _rule;

        public FieldValidation(T rule)
        {
            _rule = rule;
            if (_rule.Messages == null)
            {
                _rule.Success = true;
                _rule.Messages = new List<string>();
            }
        }

        private void AddMessage(string mensagem)
        {
            _rule.Success = false;
            _rule.Messages.Add(mensagem);
        }

        public FieldValidation<T> IsRequired(Func<T, string> seletor, string nomePropriedade)
        {
            if (string.IsNullOrEmpty(seletor(_rule)))
            {
                AddMessage(string.Format("O campo {0} é obrigatório.", nomePropriedade));
            }

            return this;
        }
    }
}
