import React, { Component } from 'react';
import { Image, StyleSheet, Text, TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';

export default class Perfil extends Component {
  constructor(props){
    super(props);
    this.state = {
      email : ''
    }
  };

  buscarDadosStorage = async () => {
    try {
      
      const valorToken = await AsyncStorage.getItem('usuario-login');
      console.warn( jwtDecode(valorToken) )

      if (valorToken !== null) {
        // this.setState({ nome : jwtDecode(valorToken).name });
        this.setState({ email : jwtDecode(valorToken).email });

      }

    } catch (error) {
      console.warn(error)
    }
  };

  componentDidMount() {
    this.buscarDadosStorage();
  };

  realizarLogout = async () => {
    try {
      
      await AsyncStorage.removeItem('usuario-login');
      this.props.navigation.navigate('Login');

    } catch (error) {
      console.warn(error)
    }
  };

  render(){
    return (
      <View style={styles.main}>

        {/* Cabeçalho - Header */}
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Text style={styles.mainHeaderText}>{"Perfil".toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <View style={styles.mainBodyInfo}>
            <View style={styles.mainBodyImg} />

            <Text style={styles.mainBodyText}>{this.state.nome}</Text>
            <Text style={styles.mainBodyText}>{this.state.email}</Text>
          </View>

          <TouchableOpacity
            style={styles.btnLogout}
            onPress={this.realizarLogout}
          >
              <Text style={styles.btnLogoutText}>sair</Text>
          </TouchableOpacity>
        </View>
        
      </View>
    );
  }
}

const styles = StyleSheet.create({

  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  },
  // cabeçalho
  mainHeader: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center'
  },
  mainHeaderRow: {
    flexDirection: 'row'
  },
  // imagem do cabeçalho
  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: '#ccc',
    marginRight: -5,
    marginTop: -12
  },
  // texto do cabeçalho
  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#999',
    fontFamily: 'Open Sans'
  },
  // linha de separação do cabeçalho
  mainHeaderLine: {
    width: 220,
    paddingTop: 10,
    borderBottomColor: '#999',
    borderBottomWidth: 1
  },

  // conteúdo do body
  mainBody: {
    flex: 4,
    alignItems: 'center',
    justifyContent: 'space-between'
  },
  // informações do usuário
  mainBodyInfo: {
    alignItems: 'center'
  },
  mainBodyImg: {
    backgroundColor: '#ccc',
    width: 100,
    height: 100,
    borderRadius: 50,
    marginBottom: 50
  },
  mainBodyText: {
    color: '#999',
    fontSize: 16,
    marginBottom: 20
  },
  // botão de logout
  btnLogout: {
    alignItems: "center",
    justifyContent: "center",
    height: 80,
    width: 240,
    borderTopWidth: 1,
    borderColor: "#ccc",
    marginBottom: 50
  },
  // texto do botão
  btnLogoutText: {
    fontSize: 16,
    fontFamily: "Open Sans",
    color: "#047D69"
  }

});