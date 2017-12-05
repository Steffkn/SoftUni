package com.company;

import java.util.Scanner;

public class _14FitStringIn20Chars {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        if (input.length() < 20) {
            System.out.println(input + new String(new char[20-input.length()]).replace("\0", "*"));
        } else {
            System.out.println(input.substring(0, 20));
        }
    }
}
