package com.company;

import java.util.Scanner;
import java.util.TreeMap;

public class _19PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        TreeMap<String, String> phonebook = new TreeMap<>();

        String line = scan.nextLine();
        while (!line.equalsIgnoreCase("end")) {
            String[] tokens = line.split(" ");
            String cmd = tokens[0];

            switch (cmd) {
                case "A":
                    phonebook.put(tokens[1], tokens[2]);
                    break;
                case "S":

                    String name = tokens[1];
                    if (phonebook.containsKey(name)) {
                        System.out.println(name + " -> " + phonebook.get(name));
                    } else {
                        System.out.println("Contact " + name + " does not exist.");
                    }
                    break;
                case "ListAll":
                    phonebook.forEach((x , y) -> System.out.println(x + " -> " + y));
                    break;
                default:
                    break;
            }

            line = scan.nextLine();
        }
    }
}
