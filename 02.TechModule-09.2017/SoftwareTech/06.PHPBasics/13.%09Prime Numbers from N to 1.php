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

    function isPrime($number){
        if ($number == 2)
        {
            return true;
        }

        $interval = sqrt($number);

        for ($i = 2; $i <= $interval; $i++)
        {
            if ($number % $i == 0)
            {
                return false;
            }
        }

        return true;
    }

    if (isset($_GET['num'])) {
        $number = intval(htmlspecialchars($_GET['num']));

        for ($i = $number; $i > 1; $i--) {
            if (isPrime($i))
            {
                echo $i . " " ;
            }
        }
    }

    ?>
</body>
</html>