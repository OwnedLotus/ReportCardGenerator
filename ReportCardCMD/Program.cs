using ReportCardCMD;

    string input;
    int numberofReps;
    bool test;

    Console.WriteLine("Please enter the amount of Students to be entered");
    READ_ERROR: input = Console.ReadLine();

    test = Int32.TryParse(input, out numberofReps);

    if (!test  || CheckIfBlank(input) == true)
    {
        Console.WriteLine("Given input was not accepted. Please Try again");
        goto READ_ERROR;
    }

    Student[] reportcard = new Student[numberofReps];

    for (int i = 0; i < reportcard.Length; i++)
    {
        reportcard[i] = new Student(i);
    }

    foreach (Student student in reportcard)
    {
        student.DisplayStudentInfo(student);
    }



static bool? CheckIfBlank(params object[] obj)
{
    bool? isBlank = null;

    foreach (var item in obj)
    {
        if ((item.ToString()) == null || (item.ToString() == "\n") || (item.ToString() == "\0"))
        {
            isBlank = true;
        }
        else
            isBlank = false;
    }

    if (isBlank == null)
        throw new NullReferenceException($"(nameof{isBlank} is null");

    return (bool)isBlank;
}