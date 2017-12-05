package com.company;

import java.util.Scanner;

public class _04VowelOrDigit {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String str = scan.nextLine();
        if (str.matches("[0-9]+")) {
            System.out.println("digit");
        }
        else if(str.matches("[aeuioy]+")){
            System.out.println("vowel");
        }
        else{
            System.out.println("other");
        }
    }
}
