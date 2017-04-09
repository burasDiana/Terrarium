<?php
/**
 * Created by PhpStorm.
 * User: fhawo
 * Date: 22-11-2016
 * Time: 10:12
 */
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Auto Terrarium</title>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

        <!-- Bootstrap min CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

        <!-- jQuery & Bootsrap JS -->
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    </head>
    <body style="padding-top: 70px;">
    <nav class="navbar navbar-default navbar-fixed-top navbar-inverse">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="index.php">
                    Auto Terrarium
                </a>
            </div>
            <ul class="nav navbar-nav navbar-right">
                <li><a href="control/GetAllData.php">All Data</a></li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Range<span class="caret"></span></a>
                    <ul class="dropdown-menu" style="min-width: 304px;">
                        <li style="margin: 0px 20px;"><h4>Get Data Range</h4></li>

                        <li role="separator" class="divider"></li>
                        <form class="form" role="form" method="post" action="control/GetInterval.php" accept-charset="UTF-8" id="GetRange">
                            <div class="form-group" style="margin: 0px 20px;">
                                <label class="control-label" for="FromDate">From:</label>
                                <input name="FromDate" type="date" class="form-control" id="FromDate" placeholder="DD-MM-YYYY" required>
                            </div>
                            <div class="form-group" style="margin: 10px 20px 0px;">
                                <label class="control-label" for="FromDate">To:</label>
                                <input name="ToDate" type="date" class="form-control" id="ToDate" placeholder="DD-MM-YYYY" required>
                            </div>
                            <li role="separator" class="divider"></li>
                            <div class="form-group" style="margin: 15px 20px;">
                                <button type="submit" class="btn btn-primary btn-block">View Range of Data</button>
                            </div>
                        </form>
                    </ul>
                </li>
            </ul>
        </div>
    </nav>
        <div class="container">
            <div class="row">
                <div class="jumbotron">
                    <h1>Auto Terrarium!</h1>
                    <p>Keep a close eye on your terrarium, while away from home.</p>
                    <p>From here you have two options available to you, via the menu-bar up top. You can select to either view all the available data we have, or you can view a range of data based on dates.</p>
                </div>
            </div>
            <!--
            <div class="row">
                <div class="col-md-12">
                    <form action="control/GetAllData.php" method="post">
                        <h1>Request a table with all Logs</h1>
                        <input type="submit" class="btn btn-default" value="View Temperature Logs">
                    </form>

                    <form class="form-horizontal" action="control/GetInterval.php" method="post">
                        <h1>Request a table based on dates</h1>

                        <div class="form-group">
                            <label for="FromDate" class="col-sm-2 control-label">FromDate</label>
                            <div class="col-sm-10">
                                <input name="FromDate" type="date" class="form-control" id="FromDate" placeholder="DD-MM-YYYY">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ToDate" class="col-sm-2 control-label">ToDate</label>
                            <div class="col-sm-10">
                                <input name="ToDate" type="date" class="form-control" id="ToDate" placeholder="DD-MM-YYYY">
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button type="submit" class="btn btn-default">Get Interval</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            -->
        </div>
    </body>
</html>