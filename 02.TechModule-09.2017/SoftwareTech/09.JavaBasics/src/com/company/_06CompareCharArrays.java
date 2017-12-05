package com.company;

import java.util.Scanner;

public class _06CompareCharArrays {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] array1 = scan.nextLine().split("[ ]+");
        String[] array2 = scan.nextLine().split("[ ]+");

        int compare = String.join("", array1).compareTo(String.join("", array2));
        if (compare < 0) {
            System.out.println(String.join("",array1));
            System.out.println(String.join("",array2));
        } else {
            System.out.println(String.join("",array2));
            System.out.println(String.join("",array1));
        }
    }
}
