<%-- 
    Document   : index
    Created on : 01-sep-2019, 1:51:15
    Author     : Bryan
--%>

<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>


<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        
        <title>No mas Accidentes</title>
        
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <%--<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">--%>
      
        
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>


    </head>
    <body >
     
    <center>
         <div   class="p-3 mb-2 bg-light text-dark"  class="mx-auto" class="rounded" style="width: 350px;" >
            
        <h2  class="text-primary" >NO MAS ACCIDENTES</h2>
        
        <br>
        <img src="https://i.ibb.co/2dkfHfM/nomas.png" alt="..." class="img-thumbnail" width="80" height="80">
        <br>
        
        <form action="login.do" ng method="POST" >
            <center>
  <div class="form-group" class="dropdown-menu p-4">
     

    <label for="exampleInputEmail1">Rut</label>
    <input type="text" class="form-control" id="exampleInputEmail1" name="txtRut" aria-describedby="emailHelp" placeholder="Ingrese su rut" required> 
    <%--  <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>--%>
  
</div>
      
  <div class="form-group">
    <label for="exampleInputPassword1">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1" name="txtClave" placeholder="Ingrese su contraseña" required >
  </div>
  <div class="form-group form-check">
      <%-- <input type="checkbox" class="form-check-input" id="exampleCheck1"> 
    <label class="form-check-label" for="exampleCheck1">Check me out</label>--%>
  </div>
  <button type="submit" class="btn btn-primary" name="btnEnviar" >Enviar</button>

   
  <c:if test="${errorLogin != null }">
    <div class="alert alert-danger" role="alert">
      
        ${errorLogin}
    </div>
  </c:if>
  
  </center>
</form>

</div>
    </center>    
        
  <%--   
          <center>

        <fieldset>
            
            </br>
            <img src="https://i.ibb.co/2dkfHfM/nomas.png" alt="..." class="img-thumbnail" width="80" height="80">
            
              
                </br>
            </br>
            <h3>Ingreso usuario</h3>
            </br>
            <form action="login.do" ng method="POST">
                <table class="loginTable" title="Acceso" >    
                    <col><col>
                    <tr>
                        <td>Rut:</td>
                        <td class="loginTable"><input type="text" name="txtRut" value="" size="15" required></td>
                    </tr>
                    <tr>
                        <td>Clave:</td>
                        <td class="loginTable"><input type="password" name="txtClave" value="" size="15" required></td>
                    </tr>
                    <tr>
                        <td></td>
                        
                        
                        <td></br></br><input type="submit" value="Enviar" name="btnEnviar" /></td>
                        </br></br>
                    </tr>
                    <tr>
                        <td></td>

                        
                    </tr>

                </table>
                </br>
                <div class="alert alert-danger" role="alert">
${errorLogin}
</div>
            </form>
        </fieldset>
</center>
  
  --%>
    </body>
</html>
