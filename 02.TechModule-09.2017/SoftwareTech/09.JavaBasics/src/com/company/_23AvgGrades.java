package com.company;

import java.util.*;
import java.util.stream.Collectors;

import static java.util.Collections.reverseOrder;

public class _23AvgGrades {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = scan.nextInt();
        scan.nextLine();
        ArrayList<Student> students = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] inputs = scan.nextLine().split(" ");
            String name = inputs[0];
            double[] grades = Arrays.stream(inputs).skip(1).mapToDouble(Double::parseDouble).toArray();
            students.add(new Student(name, grades));
        }

        ArrayList<Student> studentsWithExcellent =
                students.stream()
                        .filter(p -> p.getAverageGrade() >= 5.0)
                        .collect(Collectors.toCollection(ArrayList::new));

        studentsWithExcellent.sort(
                Comparator
                        .comparing(Student::getName)
                        .thenComparing(Student::getAverageGrade, reverseOrder())
        );

        for (Student student : studentsWithExcellent) {
            System.out.printf("%s -> %.2f%n", student.getName(), student.getAverageGrade());
        }
    }
}

class Student {
    public Student(String name, double[] grades) {
        this.name = name;
        this.grades = grades;
    }

    private String name;
    private double[] grades;
    private double averageGrade;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setGrades(double[] grades) {
        this.grades = grades;
    }

    public double[] getGrades() {
        return this.grades;
    }

    public double getAverageGrade() {
        double sum = 0;
        for (int i = 0; i < this.grades.length; i++) {
            sum += this.grades[i];
        }

        return sum / grades.length;
    }
}