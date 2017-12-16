<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num"/>
    <input type="submit"/>
</form>
    <?php
    if (isset($_GET['num'])) {
        $number = intval(htmlspecialchars($_GET['num']));
        $current = 1;
        $next = 1;

        echo $current . " ";
        echo $next . " ";

        for ($i = 3; $i <= $number; $i++) {
            $temp = $current;
            $current = $next;
            $next = $next + $temp;
            echo $next . " ";
        }
    }
    ?>
</body>
</html>