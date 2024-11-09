using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using FluentResults;
// using FluentValidation.Results;

namespace EmployeesCRUD;

public static class Extensions
{
    //пристройка (расширение) к классу Result, чтобы не лезть в нугет, а написать метод снаружи
    public static string StringifyErrors<T>(this Result<T> result)
    {
        return string.Join(";", result.Errors.Select(x => x.Message));
    }

    // public static string StringifyErrors(this ValidationResult result)
    // {
    //     return string.Join(";", result.Errors.Select(x => x.ErrorMessage));
    // }

    public static long GetUserId(this HttpContext context)
    {
        var idString = context.User.FindFirst("Id")?.Value;
        if (idString is null)
        {
            throw new Exception("В токене не было ID");
        }

        if (long.TryParse(idString, out var id))
        {
            return id;
        }
        throw new Exception("В токене ID не число");
    }
}