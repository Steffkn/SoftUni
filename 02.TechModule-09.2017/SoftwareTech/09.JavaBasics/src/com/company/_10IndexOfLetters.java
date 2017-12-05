package com.company;

import java.util.Scanner;

public class _10IndexOfLetters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        int aAsInt = (int)'a';
        for (int i = 0; i < input.length(); i++) {
            System.out.println(input.charAt(i) + " -> " + ((int)input.charAt(i) - aAsInt));
        }
    }
}
