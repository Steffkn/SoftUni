using System;
using System.Text;

public class Worker : Human
{
    private decimal _weekSelary;
    private decimal _workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSelary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSelary = weekSelary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSelary
    {
        get => _weekSelary;
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            _weekSelary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get => _workHoursPerDay;
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            _workHoursPerDay = value;
        }
    }

    public decimal SalaryPerHour => WeekSelary / (WorkHoursPerDay * 5);

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Week Salary: {this.WeekSelary:f2}");
        sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");
        return sb.ToString().TrimEnd();
    }
}
