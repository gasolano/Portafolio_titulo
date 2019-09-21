
package WSPrevencion;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
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
 *         &lt;element name="r" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="p" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
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
    "r",
    "p"
})
@XmlRootElement(name = "ValidarUsuarioJava")
public class ValidarUsuarioJava {

    @XmlElementRef(name = "r", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<String> r;
    @XmlElementRef(name = "p", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<String> p;

    /**
     * Obtiene el valor de la propiedad r.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getR() {
        return r;
    }

    /**
     * Define el valor de la propiedad r.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setR(JAXBElement<String> value) {
        this.r = value;
    }

    /**
     * Obtiene el valor de la propiedad p.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getP() {
        return p;
    }

    /**
     * Define el valor de la propiedad p.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setP(JAXBElement<String> value) {
        this.p = value;
    }

}
