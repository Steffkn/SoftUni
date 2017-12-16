<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
	<style>
		table * {
			border: 1px solid black;
			width: 50px;
			height: 50px;
		}
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <?php
    $redColor = 0;
    $greenColor = 0;
    $blueColor = 0;

    while ($blueColor <= 255){
    ?>
    <tr>
        <td style="background-color: rgb(<?= $redColor?>, 0, 0)"> </td>
        <td style="background-color: rgb(0, <?= $greenColor?>, 0)"> </td>
        <td style="background-color: rgb(0, 0, <?= $blueColor?>)"> </td>
    </tr>
    <?php
        $redColor += 51;
        $greenColor += 51;
        $blueColor += 51;
    }
    ?>
</table>
</body>
</html>