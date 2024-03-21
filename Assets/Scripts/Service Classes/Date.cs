using System;

//Класс времени в виде даты для игры
public class Date
{
    private int year;
    private int month;
    private int day;

    public int Year => year;
    public int Month => month;
    public int Day => day;

    public event Action onDateChange;

    public Date(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    public void AddDay()
    {
        if (day + 1 > 30)
        {
            AddMonth();
            day = 1;
        }
        else
        {
            day++;
        }

        onDateChange?.Invoke();
    }

    public void AddMonth()
    {
        if (month + 1 > 12)
        {
            AddYear();
            month = 1;
        }
        else
        {
            month++;
        }

        onDateChange?.Invoke();
    }

    public void AddYear()
    {
        year++;

        onDateChange?.Invoke();
    }
}

