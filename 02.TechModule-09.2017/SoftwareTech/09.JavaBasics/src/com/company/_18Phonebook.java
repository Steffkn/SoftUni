package com.company;

import java.util.LinkedHashMap;
import java.util.Scanner;

public class _18Phonebook {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        LinkedHashMap<String, String> phonebook = new LinkedHashMap<>();

        String line = scan.nextLine();
        while (!line.equalsIgnoreCase("end")) {
            String[] tokens = line.split(" ");
            String cmd = tokens[0];
            String name = tokens[1];

            switch (cmd) {
                case "A":
                    phonebook.put(name, tokens[2]);
                    break;
                case "S":
                    if (phonebook.containsKey(name)) {
                        System.out.println(name + " -> " + phonebook.get(name));
                    } else {
                        System.out.println("Contact " + name + " does not exist.");
                    }
                    break;
                default:
                    break;
            }

            line = scan.nextLine();
        }
    }
}
