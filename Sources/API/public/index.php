<?php

use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Slim\Factory\AppFactory;

require __DIR__ .'/../vendor/autoload.php';
require __DIR__.'/../config/Database.php';

$app = AppFactory::create();

$app->get('/', function (Request $request, Response $response, $args) {
    $response->getBody()->write("Hello world!");
    return $response;
});

require __DIR__.'/../routes/Inscrit.php';
require __DIR__.'/../routes/Banque.php';
require __DIR__.'/../routes/Compte.php';
require __DIR__.'/../routes/Operation.php';
require __DIR__.'/../routes/Planification.php';
require __DIR__.'/../routes/Echeance.php';

$app->run();
?>