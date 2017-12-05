package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class _12BombNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] array = Arrays.asList(
                scan.nextLine()
                        .split("[ ]+"))
                .stream()
                .mapToInt(Integer::parseInt)
                .toArray();

        ArrayList<Integer> numbers = new ArrayList<>(array.length);

        for (int i = 0; i < array.length; i++) {
            numbers.add(array[i]);
        }

        int[] input = Arrays.stream(
                scan.nextLine()
                        .split("[ ]+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        int number = input[0];
        int power = input[1];

        int index = numbers.indexOf(number);

        while (index >= 0) {
            int count = power + power + 1;
            int pos = index - power;

            if (pos < 0) {
                count += pos;
                pos = 0;
            }

            for (int i = 0; i < count; i++) {
                if (numbers.size() > pos && pos >= 0) {
                    numbers.remove(pos);
                }
            }
            index = numbers.indexOf(number);
        }
        long sum = 0;

        for (int i = 0; i < numbers.size(); i++) {
            sum += numbers.get(i);
        }

        System.out.println(sum);
    }
}
