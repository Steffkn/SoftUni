package com.company;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class _07MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        List<String> list = Arrays.asList(
                scan.nextLine()
                        .split("[ ]+"));
        int currentElement = 0;
        int start = 0;
        int len = 1;
        int bestLen = 0;
        int bestStart = 0;

        int[] numbers = list.stream()
                .mapToInt(Integer::parseInt)
                .toArray();
        if (numbers.length >0){
            currentElement = numbers[0];
        }

        for (int i = 1; i < numbers.length; i++) {
            if (currentElement == numbers[i]){
                len++;
                if(len > bestLen){
                    bestLen = len;
                    bestStart = start;
                }
            }
            else{
                len = 1;
                start = i;
            }

            currentElement = numbers[i];
        }

        for (int i = bestStart; i < bestStart + bestLen ; i++) {
            System.out.print(numbers[i] + " ");
        }
    }
}
