package com.company;

import java.util.Scanner;

public class _13ReverseString {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String str = scan.nextLine();

        for (int i = str.length()-1; i >=0 ; i--) {
            System.out.print(str.charAt(i));
        }
    }
}
