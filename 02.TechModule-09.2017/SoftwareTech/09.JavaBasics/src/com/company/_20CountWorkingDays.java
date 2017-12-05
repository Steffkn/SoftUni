package com.company;

import java.text.ParseException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Scanner;

public class _20CountWorkingDays {
    public static void main(String[] args) throws ParseException {
        Scanner scan = new Scanner(System.in);
        DateTimeFormatter format = DateTimeFormatter.ofPattern("dd-MM-yyyy");

        LocalDate startDate = LocalDate.parse(scan.nextLine(), format);
        LocalDate endDate = LocalDate.parse(scan.nextLine(), format).plusDays(1);

        ArrayList<LocalDate> holidays = new ArrayList<>();
        holidays.add(LocalDate.parse("01-01-1900", format));
        holidays.add(LocalDate.parse("03-03-1900", format));
        holidays.add(LocalDate.parse("01-05-1900", format));
        holidays.add(LocalDate.parse("06-05-1900", format));
        holidays.add(LocalDate.parse("24-05-1900", format));
        holidays.add(LocalDate.parse("06-09-1900", format));
        holidays.add(LocalDate.parse("22-09-1900", format));
        holidays.add(LocalDate.parse("01-11-1900", format));
        holidays.add(LocalDate.parse("24-12-1900", format));
        holidays.add(LocalDate.parse("25-12-1900", format));
        holidays.add(LocalDate.parse("26-12-1900", format));

        int workingDaysCount = 0;
        while (startDate.isBefore(endDate)) {
            boolean isWorkingDay = true;
            if (startDate.getDayOfWeek().getValue() != 6 && startDate.getDayOfWeek().getValue() != 7) {
                for (LocalDate holiday : holidays) {
                    if (holiday.getMonthValue() == startDate.getMonthValue()
                            && holiday.getDayOfMonth() == startDate.getDayOfMonth()) {
                        isWorkingDay = false;
                        break;
                    }
                }
            } else {
                isWorkingDay = false;
            }

            if (isWorkingDay) {
                workingDaysCount++;
            }
            startDate = startDate.plusDays(1);
        }

        System.out.println(workingDaysCount);
    }
}
