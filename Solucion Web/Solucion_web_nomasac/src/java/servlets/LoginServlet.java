/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servlets;

import WSPrevencion.PrevencionSvc;
import clases.Cliente;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;


/**
 *
 * @author Diego
 */
@WebServlet(name = "LoginServlet", urlPatterns = {"/login.do"})
public class LoginServlet extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        HttpSession session = request.getSession();
        
        
        
        request.setAttribute("errorLogin", null);
        String rut = request.getParameter("txtRut");
        String clave = request.getParameter("txtClave");
        int valido = 0;
    
        
       valido = new Cliente().validarUsuarioJava(rut, clave);

        
        
        
        //try {
          //  cd = new ClienteDAOImpl();
            //c1 = cd.Verificar(rut);

        //} catch (SQLException ex) {
          //  Logger.getLogger(LoginServlet.class.getName()).log(Level.SEVERE, null, ex);
        //}
        
             if (valido == 0) {
            
            request.setAttribute("errorLogin", "usuario no registrado");
       
            request.getRequestDispatcher("index.jsp").forward(request, response);
             return;
        }

        if (valido == 5) {
            
            request.setAttribute("errorLogin", "usuario no registrado");
       
            request.getRequestDispatcher("index.jsp").forward(request, response);
             return;
        }
        
        //administrador
         if (valido == 3) {
            
            request.setAttribute("errorLogin", "usuario no permitido");
       
            request.getRequestDispatcher("index.jsp").forward(request, response);
             return;
        }
        
        //profesional
        if (valido == 2) {
            request.getRequestDispatcher("Inicio.jsp").forward(request, response);
        }
        
        //cliente
        if (valido == 1) {
            request.getRequestDispatcher("Cliente.jsp").forward(request, response);
        }
        
     

 

 

   
    
    } 

}

  
    
   


