using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager.Models
{
    public readonly record struct MethodResult(bool IsSuccess, string? Error)
    {
        public static MethodResult Success() => new(true, null);
        public static MethodResult Fail(string? error) => new(false, error);
    }
}
