package com.company;

import java.util.Scanner;

public class _01HexToDec {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String str = scan.nextLine();
        if (str.equalsIgnoreCase("true")) {
            System.out.println("Yes");
        } else if (str.equalsIgnoreCase("false")) {
            System.out.println("No");
        }
    }
}
