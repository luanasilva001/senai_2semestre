import React, { Component } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Home from './home'
import Cadastrar from './cadastro'

const bottomTab = createBottomTabNavigator();

export default class Main extends Component{

  render(){
    return (
      <View style={styles.main}>
        <bottomTab.Navigator
        initialRouteName = 'Eventos'
        tabBarOptions = {{
            showLabel : false,
            showIcon : true,
            activeBackgroundColor : '#00E17B',
            inactiveBackgroundColor : '#00B764',
            activeTintColor : 'white',
            inactiveTintColor : 'white',
            style : { height : 70 }
        }}
        screenOptions = { ({ route }) => ({
            tabBarIcon : () => {
            if (route.name === 'Home') {
                return(
                <Image 
                    source={require('../../assets/img/home.png')}
                    style={styles.tabBarIcon}
                />
                )
            }

            if (route.name === 'Cadastrar') {
                return(
                <Image 
                    source={require('../../assets/img/mais.png')}
                    style={styles.tabBarIcon}
                />
                )
            }

            }
        }) }
        >
        <bottomTab.Screen name='Home' component={Home} />
        <bottomTab.Screen name='Cadastrar' component={Cadastrar} />
        </bottomTab.Navigator>
      </View>
    );
  }
}

const styles = StyleSheet.create({

  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#00E17B'
  },

  tabBarIcon : {
    tintColor: 'white',
    width : 50,
    height : 50
  }
  
});