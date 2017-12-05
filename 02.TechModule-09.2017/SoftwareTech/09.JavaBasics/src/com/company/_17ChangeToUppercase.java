package com.company;

import java.util.Scanner;

public class _17ChangeToUppercase {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        String openTag = "<upcase>";
        String closeTag = "</upcase>";
        StringBuilder result = new StringBuilder();
        int crossHair = 0;
        int indexOfTag = line.indexOf(openTag, crossHair);

        while (indexOfTag != -1) {
            int indexOfCloseTag = line.indexOf(closeTag, crossHair);
            String textToUpCase = line.substring(indexOfTag + openTag.length(), indexOfCloseTag);
            result.append(line.substring(crossHair, indexOfTag));

            result.append(textToUpCase.toUpperCase());
            crossHair = indexOfCloseTag + closeTag.length();
            indexOfTag = line.indexOf(openTag, crossHair);
        }

        result.append(line.substring(crossHair));

        System.out.println(result.toString());
    }
}
