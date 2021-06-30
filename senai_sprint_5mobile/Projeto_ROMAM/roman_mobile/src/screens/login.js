import React, { Component } from 'react';
import {ImageBackground, TouchableOpacity ,TextInput, Image, StyleSheet, Text, View } from 'react-native';
import { color } from 'react-native-reanimated';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../services/api';

export default class Login extends Component{
    constructor(props)
    {
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    }

  login = async () =>
  {

    console.warn(this.state.email + ' ' + this.state.senha);

    try {

      const resp = await api.post('/login', {
        email : this.state.email,
        senha : this.state.senha,
      });

      const token = resp.data.token;

      console.warn(token);

      await AsyncStorage.setItem('userToken', token)
      
      this.props.navigation.navigate('main')

    } catch (error) {
      console.warn(error);
    }

  }

  render()
  {
    return (
        <View style={styles.container}>
          <ImageBackground source={require('../../assets/Img/fundo.jpg')} style={StyleSheet.absoluteFillObject}>
            <View style={styles.fundoImg}>

              <View style={styles.headerLogin}>
                <Image 
                source={require('../../assets/Img/lock-solid.png')} 
                style={styles.headerLoginImg}
                >
                </Image>
              </View>

              <View style={styles.mainLogin}>

                <TextInput
                  style={styles.MainInput}
                  placeholder="Email"
                  placeholderTextColor="white"
                  keyboardType='email-address'
                  onChangeText={email => this.setState({email})}
                />

                <TextInput
                  style={styles.MainInput}
                  placeholder="Senha"
                  placeholderTextColor="white"
                  secureTextEntry={true}
                  keyboardType='email-address'
                  onChangeText={senha => this.setState({senha})}
                />

                <TouchableOpacity style={styles.loginBtn} onPress={this.login}>
                  <Text style={styles.loginBtnText}>{'login'.toUpperCase()}</Text>
                </TouchableOpacity>

              </View>

              <View style={styles.footerLogin}>
                <Image
                  source={require('../../assets/Img/logo.png')}
                  style={styles.footerLoginImg}
                />
              </View>

            </View>
          </ImageBackground>
        </View>
      );
  }
}

const styles = StyleSheet.create({

  fundoImg: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(0 , 0 , 0 , 0.56)'
  },

  headerLogin: {
    flex: 0.25,
    justifyContent: 'center',
    alignItems: 'center',
    // backgroundColor: 'red'
  },
  
  headerLoginImg: {
    width: 130,
    height: 150,
    tintColor: 'white'
  },

  mainLogin: {
    flex: 0.5,
    justifyContent: 'center',
    alignItems: 'center',
    // backgroundColor: 'red'
  },

  MainInput : {
    width: 270,
    height: 35,
    fontSize: 18,
    fontFamily: 'Arial',
    color: 'white',
    borderBottomWidth: 2,
    borderBottomColor: 'white',
    marginBottom : 50
  },

  loginBtn: {
    width: 135,
    height: 40,
    borderRadius: 7,
    backgroundColor: 'white',
    justifyContent: 'center',
    alignItems: 'center',
  },

  loginBtnText: {
    fontSize: 20,
    fontFamily: 'Arial',
  },

  footerLogin: {
    flex: 0.25,
    justifyContent: 'center',
    alignItems: 'center',
  },

  footerLoginImg: {
    width: 400,
    height: 400,
  },

  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
});