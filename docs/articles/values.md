# Values

A value is a terminal token representing a concrete element. This can be:

- An <xref:System.Int32>
- Any floating point number, like <xref:System.Double>
- A <xref:System.DateTime> or <xref:System.TimeSpan>
- A <xref:System.Boolean>
- A <xref:System.String>
- A <xref:NCalc.Domain.Function>
- An <xref:NCalc.Domain.Identifier> (parameter).

## Integers

They are represented using numbers. 

```
123456
```

They are evaluated as <xref:System.Int32>. If the value is too big, it will be evaluated as <xref:System.Int64>.

## Floating point numbers

Use the dot to define the decimal part. 

```
123.456
.123
```
They are evaluated as <xref:System.Double>, unless you use <xref:NCalc.ExpressionOptions.DecimalAsDefault>.

## Scientific notation

You can use the e to define power of ten (10^).
```
1.22e1
1e2
1e+2
1e+2
1e-2
.1e-2
1e10
```
They are evaluated as <xref:System.Double>, unless you use <xref:NCalc.ExpressionOptions.DecimalAsDefault>.

## DateTime

Must be enclosed between sharps. 

```
#2008/01/31# // for en-US culture
#08/08/2001 09:30:00# 
```
NCalc uses the current Culture to evaluate them.

## TimeSpan

Must be enclosed between sharps.
```
#20:42:00#
```

## Booleans
Booleans can be either `true` or `false`.

```
true
```
## Strings

Any character between single quotes "'" are evaluated as <xref:System.String>. 

```
'hello'
```

You can escape special characters using \\, \', \n, \r, \t.

## Function

A function is made of a name followed by braces, containing optionally any value as arguments.

```
  Abs(1), doSomething(1, 'dummy')
```
Please read the [functions page](functions.md) for details.

## Parameters

A parameter as a name, and can be optionally contained inside brackets or double quotes.

```
  2 + x, 2 + [x]
```

Please read the [parameters page](parameters.md) for details.