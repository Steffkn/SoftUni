package com.company;

import java.util.Scanner;

public class _16URL_Parser {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();

        String protocol = "";
        String server = "";
        String resource = "";

        int indexOfProtocol = line.indexOf("://");

        if (indexOfProtocol != -1) {
            protocol = line.split("://")[0];
            indexOfProtocol += 3;
        } else {
            indexOfProtocol = 0;
        }

        int indexOfResource = line.indexOf("/", indexOfProtocol);

        if (indexOfResource != -1) {
            server = line.substring(indexOfProtocol, indexOfResource);
            resource = line.substring(indexOfResource + 1);
        } else {
            server = line.substring(indexOfProtocol);
        }

        System.out.println("[protocol] = \"" + protocol + "\"");
        System.out.println("[server] = \"" + server + "\"");
        System.out.println("[resource] = \"" + resource + "\"");
    }
}
