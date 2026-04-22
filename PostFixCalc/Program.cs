using MyStackLib;
// 5 6 7 * 1 -

string[] input = new string[] { "5", "6", "7", "*", "1", "-", };
MyStack<int> values = new MyStack<int>();

foreach(string token in input)
{
    int value = 0;

    if (int.TryParse(token, out value))
        values.Push(value);
    else
    {
        int rhet = values.Pop();
        int lht = values.Pop();

        switch (token)
        {
            case "+":
                values.Push(lht + rhet);
                break;
            case "-":
                values.Push(lht - rhet);
                break;
            case "*":
                values.Push(lht * rhet);
                break;
            case "/":
                values.Push(lht / rhet);
                break;
            default:
                throw new ArgumentException("Ther is unexpected operator!");
        }
    }
}