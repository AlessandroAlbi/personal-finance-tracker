import Keycloak from 'keycloak-js'
import KeyCloakConfiguration from './resources/keycloak.json'
 
// Setup Keycloak instance as needed
// Pass initialization options as required or leave blank to load from 'keycloak.json'
const keycloak = new Keycloak(KeyCloakConfiguration);
 
export default keycloak