<?php
/**
 * Created by PhpStorm.
 * User: fhawo
 * Date: 05-12-2016
 * Time: 12:35
 */

// Turn off all error reporting
error_reporting(0);

require_once '../vendor/autoload.php';
Twig_Autoloader::register();

$loader = new Twig_Loader_Filesystem('../view');
$twig = new Twig_Environment($loader, array('auto_reload' => true));
$template = $twig->loadTemplate('interval.html.twig');

 $client = new SoapClient('http://webservice-fran-easj.azurewebsites.net/Service1.svc?wsdl');

 //http://localhost:52225/Service1.svc?wsdl
 //http://webservice-fran-easj.azurewebsites.net/Service1.svc?wsdl

 $FromDate = $_POST["FromDate"];
 $ToDate = $_POST["ToDate"];

 $FromExplode = explode("-", $FromDate);
 $ToExplode = explode("-", $ToDate);

 $FinalFrom = $FromExplode[2]."-".$FromExplode[1]."-".$FromExplode[0]." 00:00:01";
 $FinalTo = $ToExplode[2]."-".$ToExplode[1]."-".$ToExplode[0]." 23:59:59";

 $parameters = array($FinalFrom, $FinalTo);

 $res = $client -> GetDataFrom(array("fromTimestamp" => $FinalFrom, "toTimestamp" => $FinalTo))-> GetDataFromResult;


$twigContent = array('list' => $res -> TemperatureLog); // fill in content for the page
echo $template->render($twigContent);