<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
$color = 0;

while ($color <= 255) {
    for ($i = $color; $i < $color + 50; $i += 5) {
        ?>
        <div style="background-color: rgb(<?= $i ?>, <?= $i ?>, <?= $i ?>)"></div>
        <?php
    }
    ?>
    <br>
    <?php
    $color += 51;
}
?>
</body>
</html>