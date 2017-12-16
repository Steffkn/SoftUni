<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
        if (isset($_GET['num'])) {
            $number = intval(htmlspecialchars($_GET['num']));
            $fist = 1;
            $second = 1;
            $third = 2;

            echo $fist . " ";
            echo $second . " ";
            echo $third . " ";

            for ($i = 4; $i <= $number; $i++) {
                $temp = $fist;
                $fist = $second;
                $second = $third;
                $third = $temp + $fist + $second;
                echo $third . " ";
            }
        }
    ?>
</body>
</html>