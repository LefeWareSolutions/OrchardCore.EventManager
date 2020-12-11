import {injectIntl} from 'react-intl';

const InjectMassage = props => props.intl.messages[props.id];
export default injectIntl(InjectMassage, {
    withRef: false
});
