 <?php
/**
 * Created by PhpStorm.
 * User: fhawo
 * Date: 22-11-2016
 * Time: 10:25
 */
 

require_once '../vendor/autoload.php';
Twig_Autoloader::register();

$loader = new Twig_Loader_Filesystem('../view');
$twig = new Twig_Environment($loader, array('auto_reload' => true));
$template = $twig->loadTemplate('AllData.html.twig');

 $client = new SoapClient('http://webservice-fran-easj.azurewebsites.net/Service1.svc?wsdl');

 $params = array();
 $res = $client -> GetAllData($params) -> GetAllDataResult;

$twigContent = array('list' => $res -> TemperatureLog); // fill in content for the page
echo $template->render($twigContent);