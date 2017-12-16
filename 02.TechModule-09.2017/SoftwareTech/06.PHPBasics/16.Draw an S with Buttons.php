<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
    $cols = 5;
    $rows = 9;
    $blueBtn = "<button style=\"background-color: blue\">1</button>";
    $greyBtn = "<button>0</button>";
    for ($i = 1; $i<= $cols; $i++) {
        echo $blueBtn;
    }
    for ($y = 0; $y < 3; $y++){
        echo "<br>";
        echo $blueBtn;

        for ($i = 1; $i<= $cols-1; $i++) {
            echo $greyBtn;
        }
    }

echo "<br>";
    for ($i = 1; $i<= $cols; $i++) {
        echo $blueBtn;
    }

    for ($y = 0; $y < 3; $y++){

        echo "<br>";
        for ($i = 1; $i<= $cols-1; $i++) {
            echo $greyBtn;
        }

        echo $blueBtn;
    }

echo "<br>";
    for ($i = 1; $i<= $cols; $i++) {
        echo $blueBtn;
    }
?>
</body>
</html>