package com.company;

import java.util.Scanner;

public class _05DecToBin {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = scan.nextInt();
        String hexNumber = Integer.toHexString(number);
        String binNumber = Integer.toBinaryString(number);

        System.out.println(hexNumber.toUpperCase());
        System.out.println(binNumber);
    }
}
