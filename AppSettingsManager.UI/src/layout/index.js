import Typography from '@material-ui/core/Typography';
import React from 'react';
import { Settings, History, Login } from 'root/pages';
import * as S from './styled';
import Menu from '../layout/Menu';
import { Route, Switch } from 'react-router-dom';

const Layout = () => {
    return (
        <S.Main>
            <S.MenuContainer>
                <Menu />
            </S.MenuContainer>
            <S.BodyContainer>
                <S.HeaderContainer>
                    <Typography component="h1" variant="h6" noWrap>
                        Application Manager
                </Typography>
                </S.HeaderContainer>
                <S.ContentContainer>
                    <Switch>
                        <Route path="/history" component={History} exact />
                        <Route path="/login" component={Login} exact />
                        <Route path="/" component={Settings} exact />
                        <Route path="*" render={() => <p>Not Found</p>} />
                    </Switch>
                </S.ContentContainer>
            </S.BodyContainer>
        </S.Main>
    );
}

export default Layout;