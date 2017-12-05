/* Library and Book are the same from 24BookLibrary task*/

package com.company;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;

public class _25BookLibraryModification {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Library lib = new Library("Library");
        DateTimeFormatter format = DateTimeFormatter.ofPattern("dd.MM.yyyy");
        int n = scan.nextInt();
        scan.nextLine();

        for (int i = 0; i < n; i++) {
            String[] input = scan.nextLine().split(" ");

            lib.addBook(new Book(
                    input[0],
                    input[1],
                    input[2],
                    LocalDate.parse(input[3], format),
                    input[4],
                    Double.parseDouble(input[5])
            ));
        }

        LocalDate inDate = LocalDate.parse(scan.nextLine(), format);

        LinkedHashMap<String, LocalDate> books = new LinkedHashMap<>();

        for (Book book : lib.getBooks()) {
            if(book.getReleaseDate().isAfter(inDate)){
                books.put(book.getTitle(), book.getReleaseDate());
            }
        }

        Comparator<Map.Entry<String, LocalDate>> compareByDate = Comparator.comparing(Map.Entry::getValue);
        Comparator<Map.Entry<String, LocalDate>> compareByName = Comparator.comparing(Map.Entry::getKey);

        books.entrySet()
                .stream()
                .sorted(compareByDate.thenComparing(compareByName))
                .forEach((Map.Entry<String, LocalDate> kvp) ->
                        System.out.printf("%s -> %s%n", kvp.getKey(), kvp.getValue().format(format))
                );
    }
}
