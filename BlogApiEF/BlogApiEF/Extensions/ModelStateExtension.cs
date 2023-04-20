using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogApiEF.Extensions
{
    public static class ModelStateExtension
    {
        //o 'this' adiciona como extensão em todos os modelstate
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        { 
            var errors = new List<string>();
            foreach (var item in modelState.Values)
            {  //expressão Linq
                errors.AddRange(item.Errors.Select(error => error.ErrorMessage));
                //Equivalente a o foreach a
                /*foreach(var error in item.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }*/
            }
            return errors;
        }
    }
}
