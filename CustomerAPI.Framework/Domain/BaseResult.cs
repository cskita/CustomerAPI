using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAPI.Framework.Domain
{
    public class BaseResult
    {
        public bool Success { get; set; }

        public List<string> Messages { get; set; }

        public static BaseResult NotOK(List<string> message)
        {
            return new BaseResult
            {
                Success = false,
                Messages = message
            };
        }

        public static BaseResult NotOK(string message)
        {
            return new BaseResult
            {
                Success = false,
                Messages = ConvertMenssageList(message)
            };
        }

        protected static List<string> ConvertMenssageList(string message)
        {
            List<string> Messages = message?.Split(";").ToList();
            Messages.RemoveAll(e => String.IsNullOrEmpty(e));

            return Messages;
        }
    }

    public class BaseResult<T> : BaseResult
    {
        public T Data { get; private set; }

        public static BaseResult<T> OK(T data, List<string> message = null)
        {
            return new BaseResult<T>()
            {
                Success = true,
                Messages = message,
                Data = data
            };
        }

        public static BaseResult<T> NotOK(T data, List<string> message)
        {
            return new BaseResult<T>()
            {
                Success = false,
                Messages = message,
                Data = data
            };
        }

        public static BaseResult<T> NotOK(T data, string message)
        {
            return new BaseResult<T>()
            {
                Success = false,
                Messages = ConvertMenssageList(message),
                Data = data
            };
        }

        public static new BaseResult<T> NotOK(string message)
        {
            return new BaseResult<T>()
            {
                Success = false,
                Messages = ConvertMenssageList(message),
                Data = default(T)
            };
        }

        public static new BaseResult<T> NotOK(List<string> message)
        {
            return new BaseResult<T>()
            {
                Success = false,
                Messages = message,
                Data = default(T)
            };
        }
    }
}
