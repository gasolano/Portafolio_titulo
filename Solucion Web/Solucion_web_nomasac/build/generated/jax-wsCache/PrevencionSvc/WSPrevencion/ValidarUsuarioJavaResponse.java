
package WSPrevencion;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Clase Java para anonymous complex type.
 * 
 * <p>El siguiente fragmento de esquema especifica el contenido que se espera que haya en esta clase.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="ValidarUsuarioJavaResult" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "validarUsuarioJavaResult"
})
@XmlRootElement(name = "ValidarUsuarioJavaResponse")
public class ValidarUsuarioJavaResponse {

    @XmlElement(name = "ValidarUsuarioJavaResult")
    protected Integer validarUsuarioJavaResult;

    /**
     * Obtiene el valor de la propiedad validarUsuarioJavaResult.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getValidarUsuarioJavaResult() {
        return validarUsuarioJavaResult;
    }

    /**
     * Define el valor de la propiedad validarUsuarioJavaResult.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setValidarUsuarioJavaResult(Integer value) {
        this.validarUsuarioJavaResult = value;
    }

}
