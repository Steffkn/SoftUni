package com.company;

import java.util.Scanner;

public class _15CensorEmailAddress {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String email = scan.nextLine();
        String text = scan.nextLine();

        int indexOfAt = email.indexOf('@');
        String replacement =  new String(new char[indexOfAt]).replace("\0", "*") + email.substring(indexOfAt);

        text = text.replaceAll(email, replacement);

        System.out.println(text);
    }
}
