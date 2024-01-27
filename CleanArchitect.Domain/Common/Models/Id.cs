using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitect.Domain.Common.Models;

public class Id
{
    public long Value { get; private set; }

    private Id(long value)
    {
        Value = value;
    }

    private Id()
    {

    }

    public static Id Create(long value)
    {
        return new Id(value);
    }
}